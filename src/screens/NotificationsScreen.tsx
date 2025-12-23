import Header from "@/components/layouts/Header";
import { View, ScrollView, Text, StyleSheet } from "react-native";
import { colors } from "@/utils/colors";

export default function NotificationsScreen() {
  return (
    <View style={styles.container}>
      <Header />

      <ScrollView
        showsVerticalScrollIndicator={false}
        contentContainerStyle={styles.scrollContent}
      >
        {/* Exemplo de notificações fake */}
        <View style={styles.notification}>
          <Text style={styles.notificationText}>Nova mensagem recebida</Text>
        </View>

        <View style={styles.notification}>
          <Text style={styles.notificationText}>Atualização disponível</Text>
        </View>

        <View style={styles.notification}>
          <Text style={styles.notificationText}>Seu plano foi renovado</Text>
        </View>
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 32,
  },
  scrollContent: {
    paddingTop: 24,
    paddingBottom: 100,
    paddingHorizontal: 20,
    gap: 12,
  },
  notification: {
    backgroundColor: colors.gray[700],
    padding: 16,
    borderRadius: 8,
  },
  notificationText: {
    color: colors.gray[100],
    fontSize: 16,
  },
});
